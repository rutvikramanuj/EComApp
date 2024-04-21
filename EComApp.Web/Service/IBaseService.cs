using EComApp.Web.Models;
using EComApp.Web.Models.Dtos;

namespace EComApp.Web.Service
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
