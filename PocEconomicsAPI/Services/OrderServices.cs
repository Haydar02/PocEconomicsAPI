using PocEconimics.Helper;
using PocEconimics.Models.DTO.OrderDTO;
using PocEconimics.Models.DTO.ResultDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocEconimics.Services
{
    public interface IOrderServices
    {
        Task<ResultDTORoot> PostOrder(OrderDTORoot order);

    }
    public  class OrderServices : IOrderServices
    {
        public async Task<ResultDTORoot> PostOrder(OrderDTORoot order)
        {
            APIRequestHandler apiRequestHandler = new APIRequestHandler();

            try
            {
                return await apiRequestHandler.PostOrder(order);
            }
            catch (Exception ex)
            {
                throw ex; 
              
            }
        }
    }
}
