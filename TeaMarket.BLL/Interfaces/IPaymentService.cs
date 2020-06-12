using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaMarket.BLL.ViewModels.Card;

namespace TeaMarket.BLL.Interfaces
{
    public interface IPaymentService
    {
        Task<bool> ConfirmPay(PostPaymentViewModel payInfo);
    }
}
