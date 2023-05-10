using AutoMapper;
using Ecommerce.Website.Application.Contacts;
using Ecommerce.Website.Database.Models;
using Ecommerce.Website.Presentation.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Website.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasesController<T> : ControllerBase
    {
        private readonly IBaseService<T> _baseService;
       

        public BasesController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }
        /// <summary>
        /// API lấy danh sách bản ghi
        /// </summary>
        /// <returns>Trả về danh sách toàn bộ bản ghi</returns>
        [HttpGet]
        public IActionResult GetAllRecords()
        {
            try
            { 
                var records = _baseService.GetAllRecords();

                //var config = new MapperConfiguration(cfg => cfg.CreateMap<T, >());
                //var mapper = config.CreateMapper();
                //var recordsDto = mapper.Map<List<UserDto>>(records);

                if (records != null)
                {
                    return StatusCode(StatusCodes.Status200OK, records);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Không có bản ghi");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }
        
        /// <summary>
        /// Tim kiem ban ghi theo id
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{recordId}")]
        public IActionResult GetRecordById([FromRoute] int recordId)
        {
            try
            {
                try
                {
                    var result = _baseService.GetRecordById(recordId);
                    if(result != null)
                    {
                        return StatusCode(StatusCodes.Status200OK, result);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status404NotFound, "Không có bản ghi");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }

        /// <summary>
        /// API khởi tạo record mới 
        /// </summary>
        /// <param name="t"></param>
        /// <returns>Id của người record khởi tạo</returns>
        [HttpPost]
        public IActionResult InsertRecord([FromBody] T entity)
        {
            try
            {
                _baseService.InsertRecord(entity);
                return StatusCode(StatusCodes.Status200OK,"Thêm mới bản ghi thành công");
          
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }

        /// <summary>
        /// API sửa người dùng theo id
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userId"></param>
        /// <returns>Sẽ trả về id người dùng được sửa</returns>
        [HttpPut]
        [Route("Users/UpdateUser")]
        public IActionResult UpdateRecordById([FromBody] T entity)
        {
            try
            {
                try
                {

                    _baseService.UpdateRecord(entity);
                    return StatusCode(StatusCodes.Status200OK, "Chỉnh sửa bản ghi thành công");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }

        /// <summary>
        /// Xoa ban ghi theo id
        /// </summary>
        /// <param name="recordID"></param>
        /// <returns></returns>
        [HttpDelete("{recordID}")]
        public IActionResult DeleteRecordById([FromRoute] int recordID)
        {
            try
            {
                _baseService.DeleteRecord(recordID);
                return StatusCode(StatusCodes.Status200OK,"Xoá bản ghi thành công");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "Lỗi chưa xác định");
            }
        }
    }
}
