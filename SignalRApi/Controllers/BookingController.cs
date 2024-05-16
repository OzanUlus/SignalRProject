using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var datas = _bookingService.TGetListAll();
            return Ok(datas);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
                Date = createBookingDto.Date,
                Mail = createBookingDto.Mail,
                Name = createBookingDto.Name,
                PersonCount = createBookingDto.PersonCount,
                PhoneNumber = createBookingDto.PhoneNumber,
            };
            _bookingService.TAdd(booking);
            return Ok("Hakkımda eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var data = _bookingService.TGetById(id);
            _bookingService.TDelete(data);
            return Ok("Hakkımda silindi");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                Date = updateBookingDto.Date,
                Mail = updateBookingDto.Mail,
                Name = updateBookingDto.Name,
                PersonCount = updateBookingDto.PersonCount,
                PhoneNumber = updateBookingDto.PhoneNumber,
                Id = updateBookingDto.Id
            };
            _bookingService.TUpdate(booking);
            return Ok("Hakkımda güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var data = _bookingService.TGetById(id);
            return Ok(data);
        }
    }
}
