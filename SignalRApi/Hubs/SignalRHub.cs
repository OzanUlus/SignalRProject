using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }
        public static int clientCount  { get; set; } = 0;  

        public async Task SendStatistic() 
        {
            var data = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", data);

            var data2 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", data2);

            var data3 = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", data3);

            var data4 = _categoryService.TPasiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", data4);

            var data5 = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", data5);

            var data6 = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", data6);

            var data7 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", data7.ToString("0.00") + "₺");

            var data8 = _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", data8);

            var data9 = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice" , data9);

            var data10 = _productService.THamburgerPriceAvg();
            await Clients.All.SendAsync("ReceiveHamburgerPriceAvg", data10);

            var data11 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", data11);

            var data12 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", data12);

            var data13 = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", data13.ToString("0.00") + "₺");

            var data14 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", data14.ToString("0.00") + "₺");

            var data15 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", data15);


        }
        public async Task SendProgress() 
        {
            var data = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", data.ToString("0.00") + "₺");

            var data2 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", data2);

            var data3 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", data3);

        }
        public async Task GetBookingList()
        {
            var data = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveGetBookingList", data);


        }
        public async Task SendNotification()
        {
            var data = _notificationService.NotifacationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveSendNotification", data);

            var data2 = _notificationService.TGetAllNotificationByFAlse();
            await Clients.All.SendAsync("ReceiveGetAllNotificationByFAlse", data2);


        }
        public async Task GetMenuTableStatus() 
        {
            var data = _menuTableService.TGetListAll();
            await Clients.All.SendAsync("ReceiveGetMenuTableStatus", data);
        }
        public async Task SendMessage(string user , string message) 
        {
          await Clients.All.SendAsync("ReceiveMessage", user , message);
        }
        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }

    }
}
