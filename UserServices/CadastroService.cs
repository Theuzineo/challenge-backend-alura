//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace UserServices
//{
//    public class CadastroService
//    {
//        //private UserDbContext _context;
//        //private IMapper _mapper;
//        //public CadastroService(AppDbContext context, IMapper mapper)
//        //{
//        //    _context = context;
//        //    _mapper = mapper;
//        //}
//        private IMapper _mapper;
//        private UserManager<IdentityUser<int>> _userManager;
//        private EmailService _emailService;

//        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService)
//        {
//            _mapper = mapper;
//            _userManager = userManager;
//            _emailService = emailService;
//        }

//        public Result RegistroUsuario(CreateCadastroDto cadastroDto)
//        {
//            var cadastro = _context.tb_Usuarios.FirstOrDefault(id => id.Email == cadastroDto.Email);
//            if (cadastro != null) return Result.Fail("Email inserido já existe");

//            cadastro = _mapper.Map<Usuarios>(cadastroDto);
//            _context.tb_Usuarios.Add(cadastro);
//            _context.SaveChanges();
//            return Result.Ok();
//        }

//        public ReadCadastroDto? GetUsuarios(string nome)
//        {
//            Usuarios? usuario = _context.tb_Usuarios.FirstOrDefault(conta => conta.Nome == nome);
//            if (usuario == null) return null;

//            return _mapper.Map<ReadCadastroDto>(usuario);

//        }
//    }
//}
