using DtoLayer.Dtos.AppUserDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers;

[Route("[controller]")]
public class RegisterController : Controller
{
    private readonly ILogger<RegisterController> _logger;
    private readonly UserManager<AppUser> _userManager;

    public RegisterController(UserManager<AppUser> userManager, ILogger<RegisterController> logger)
    {
            _userManage
     
     userManage
    r;
            _logge
     
     logge
    r;
        }

    [HttpGet]
    public IActionResult In8dex()
    {
            retur
     Vie
    w
    (
    );
        }

    [HttpPost]
    public async Task<IActionResult> Index(AppUserRegisterRequest request)
    {
            i
     
    (ModelStat
    e
    .IsVali
    d)
            {
                Rando
     rando
     
     ne
     Rando
    m
    (
    );
                Strin
     cod
     
     rando
    m
    .Nex
    t
    (10000
    0
     99999
    9
    )
    .ToStrin
    g
    (
    );
                AppUse
     use
     
     ne
     AppUser
                {
                    UserNam
     
     reques
    t
    .Usernam
    e,
                    Emai
     
     reques
    t
    .Emai
    l,
                    Nam
     
     reques
    t
    .Nam
    e,
                    Surnam
     
     reques
    t
    .Surnam
    e,
                    Cit
     
     "İstanbul
    ",
                    Distric
     
     "Kadıköy
    ",
                    ImageUr
     
     "default.png
    ",
                    ConfirmCod
     
     code
                
    }
     va
     resul
     
     awai
     _userManage
    r
    .CreateAsyn
    c
    (use
    r
     reques
    t
    .Passwor
    d
    )
     i
     
    (resul
    t
    .Succeede
    d)
                
     strin
    g
     senderEmai
     
     Environmen
    t
    .GetEnvironmentVariabl
    e
    ("EMAIL_ADDRESS
    "
    );
                    strin
    g
     senderPasswor
     
     Environmen
    t
    .GetEnvironmentVariabl
    e
    ("EMAIL_PASSWORD
    "
    );
                    va
     emai
     
     ne
     MimeMessag
    e
    (
    )
     emai
    l
    .Fro
    m
    .Ad
    d
    (ne
     MailboxAddres
    s
    ("EasyCashApp
    "
     senderEmai
    l
    )
    );
                    emai
    l
    .T
    o
    .Ad
    d
    (ne
     MailboxAddres
    s
    ($"
    {use
    r
    .Nam
    e} 
    {use
    r
    .Surnam
    e}
    "
     use
    r
    .Emai
    l
    )
    )
     emai
    l
    .Subjec
     
     "EasyCashApp
    ";
                    emai
    l
    .Bod
     
     ne
     TextPar
    t
    (MimeKi
    t
    .Tex
    t
    .TextForma
    t
    .Htm
    l
     {
                        Tex
     
     $"<h1>Email Verification</h1><br><p>Verification code: 
    {cod
    e}</p>"
                    
    }
     usin
     
    (va
     smt
     
     ne
     SmtpClien
    t
    (
    ))
                    {
                        smt
    p
    .Connec
    t
    ("smtp.gmail.com
    "
     58
    7
     fals
    e
    )
     smt
    p
    .Authenticat
    e
    (senderEmai
    l
     senderPasswor
    d
    )
     smt
    p
    .Sen
    d
    (emai
    l
    );
                        smt
    p
    .Disconnec
    t
    (tru
    e
    );
                    
     _logge
    r
    .LogInformatio
    n
    ("User created a new account with password.
    "
    )
     TempDat
    a
    ["Mail
    "
     
     reques
    t
    .Emai
    l
     retur
     RedirectToActio
    n
    ("Index
    "
     "ConfirmMail
    "
    );
                
     foreac
     
    (IdentityErro
     erro
     i
     resul
    t
    .Error
    s)
                {
                    ModelStat
    e
    .AddModelErro
    r
    ("
    "
     erro
    r
    .Descriptio
    n
    );
                }
            
     retur
     Vie
    w
    (
    );
        }
}