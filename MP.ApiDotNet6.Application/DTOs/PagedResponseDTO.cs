using System;
namespace MP.ApiDotNet6.Application.DTOs
{
	public class PagedResponseDTO<T>
	{
        public PagedResponseDTO(int totalRegisters, List<T> data)
        {
            TotalRegisters = totalRegisters;
            Data = data;
        }

        public int TotalRegisters { get; private set; }
        public List<T> Data { get; private set; }        
	}
}

