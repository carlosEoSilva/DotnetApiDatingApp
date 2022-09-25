using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    //-A rota para acessar este controller é 'api/Users' porque o nome da classe começa com 'Users'.
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        //-agora a classe tem acesso ao banco de dados por meio do DataContext.
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        //-Acessando o endpoint sem parâmetros.
        [HttpGet]
        //-o IEnumerable possui menos recursos do que o List.
        public async Task<ActionResult<IEnumerable<AppUser>>>GetUsers(){
            
            //-ToListAsync() é a versão assíncrona do ToList().
            return await _context.Users.ToListAsync();
        
        }

        //-Acessando o endpoint com parâmetros.
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>>GetUser(int id){
            
            //-FindAsync() é a versão assíncrona do Find().
            return await _context.Users.FindAsync(id);
        }


    }
}