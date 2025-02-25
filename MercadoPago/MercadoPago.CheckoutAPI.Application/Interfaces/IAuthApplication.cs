using MercadoPago.CheckoutAPI.Application.Dtos.Commons.Response;
using MercadoPago.CheckoutAPI.Application.Dtos.Users.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoPago.CheckoutAPI.Application.Interfaces
{
    public interface IAuthApplication
    {
        Task<BaseResponse<string>> Login(TokenRequestDto bodyRequest);
    }
}
