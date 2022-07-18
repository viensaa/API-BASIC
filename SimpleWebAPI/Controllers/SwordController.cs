﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Data.DAL;
using SampleWebAPI.Domain;
using SimpleWebAPI.DTO;

namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwordController : ControllerBase
    {
        private readonly ISword _swordDAL;
        private readonly IMapper _mapper;

        public SwordController(ISword SwordDAL,IMapper mapper)
        {
            _swordDAL = SwordDAL;
            _mapper = mapper;
        }

        //memanggil semua data
        [HttpGet]
        public async Task<IEnumerable<SwordDTO>> Get()
        {
            var results = await _swordDAL.GetAll();

            var data = _mapper.Map<IEnumerable<SwordDTO>>(results);
            return data;
        }

        //GetdatabyName
        [HttpGet("GetByName/{name}")]
        public async Task<IEnumerable<SwordDTO>>Get(string name)
        {
            var results = await _swordDAL.GetByName(name);

            var data = _mapper.Map<IEnumerable<SwordDTO>>(results);
            return data;
        }

        //GetByid
        [HttpGet("GetById/{id}")]
        public async Task<SwordDTO>Get(int id)
        {
            var result = await _swordDAL.GetById(id);
            //if (result == null) throw new Exception("Data tidak di temukan");

            var data = _mapper.Map<SwordDTO>(result);
            return data;
        }

        //insert
        [HttpPost("insert")]
        public async Task<ActionResult> Post(SwordCreateDTO swordCreateDTO)
        {
            try
            {
                var NewSword = _mapper.Map<Sword>(swordCreateDTO);                
                var result = await _swordDAL.Insert(NewSword);
                var DataRead = _mapper.Map<SwordDTO>(result);
                return CreatedAtAction("Get", new { id = result.Id }, DataRead);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Delete
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult>Delete(int id)
        {
            try
            {
                await _swordDAL.DeleteById(id);
                return Ok("data berhasil di hapus");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //Update
        [HttpPut("Update")]
        public async Task<ActionResult>Put(SwordDTO swordDTO)
        {
            try
            {
                var UpdateSword = _mapper.Map<Sword>(swordDTO);
                var result = await _swordDAL.Update(UpdateSword);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //mengambil data samurai dan sword
        [HttpGet("samruaisowrdwithelement")]
        public async Task<IEnumerable<SwordSamuraiElementDTO>> GetSamuraiSwordWithElement()
        {
            var results = await _swordDAL.SamuraiSwordWithElement();
            var DataRead = _mapper.Map<IEnumerable<SwordSamuraiElementDTO>>(results);
            return DataRead;

        }




    }
}
