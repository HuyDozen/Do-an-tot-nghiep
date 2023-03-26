using Ecommerce.Website.Application.Contacts;
using Ecommerce.Website.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Website.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : BasesController<Address>
    {
        private readonly IAddressService _addressService;
        public AddressesController(IAddressService addressService) : base(addressService)
        {
            _addressService = addressService;
        }
    }
}
