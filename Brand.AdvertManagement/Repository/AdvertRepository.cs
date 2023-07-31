﻿using AutoMapper;
using Brand.AdvertManagement.Entities;
using Brand.AdvertManagement.Model.DTO.Request;
using Brand.AdvertManagement.Model.DTO.Response;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data.Common;

namespace Brand.AdvertManagement.Repository
{
    public class AdvertRepository : IAdvertRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        private const int PAGE_SIZE = 50;

        public AdvertRepository(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<AdvertResponseDto> GetAdvert(GetAdvertRequestDto requestDto)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
                await connection.OpenAsync();

                var response = new AdvertResponseDto();
                string commandText = $"SELECT * FROM {typeof(Advert).Name} WHERE Id = @id";
                var queryArgs = new { Id = requestDto.Id };

                var advert = await connection.QueryFirstAsync<Advert>(commandText, queryArgs);
                await connection.CloseAsync();

                return _mapper.Map<AdvertResponseDto>(advert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AdvertListResponseDto> GetAdvertList(GetAdvertListByFilterRequestDto requestDto)
        {
            try
            {
                AdvertListResponseDto response = new AdvertListResponseDto(requestDto.Page);
                NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
                await connection.OpenAsync();

                string commandText = $"SELECT * FROM {typeof(Advert).Name} ";
                string whereText = string.Empty;

                // if where statement bigger than 1 then this filled as AND operator
                string whereAndStatement = string.Empty;

                if (requestDto.CategoryId != null)
                {
                    whereText += $"CategoryId IN ({string.Join(", ", requestDto.CategoryId.ToArray())}) ";
                    whereAndStatement = "AND";
                }

                if (requestDto.MinPrice != null)
                {
                    whereText += $" {whereAndStatement} Price >= {requestDto.MinPrice}";
                    whereAndStatement = "AND";
                }

                if (requestDto.MaxPrice != null)
                {
                    whereText += $" {whereAndStatement} Price <= {requestDto.MaxPrice}";
                    whereAndStatement = "AND";
                }

                if (requestDto.Gear != null)
                {
                    whereText += $" {whereAndStatement} Gear IN ('{string.Join("', '", requestDto.Gear.ToArray())}')";
                    whereAndStatement = "AND";
                }

                if (requestDto.Fuel != null)
                {
                    whereText += $" {whereAndStatement} Fuel IN ('{string.Join("', '", requestDto.Fuel.ToArray())}') ";
                }

                var queryArgs = new
                {
                };

                commandText += (string.IsNullOrEmpty(whereText)) ? string.Empty : string.Format($" WHERE {whereText}");

                if (requestDto.Sort != null)
                {
                    commandText += $" ORDER BY {requestDto.Sort.Split('.')[0]} {requestDto.Sort.Split('.')[1]} ";
                }

                commandText += $"LIMIT {PAGE_SIZE} OFFSET {PAGE_SIZE * requestDto.Page}";

                var advertList = await connection.QueryAsync<Advert>(commandText, queryArgs);
                await connection.CloseAsync();

                response.Adverts = _mapper.Map<List<AdvertListItemResponseDto>>(advertList);
                response.Total = response.Adverts.Count();

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task VisitAdvert(VisitAdvertRequestDto requestDto)
        {
            throw new NotImplementedException();
        }
    }
}
