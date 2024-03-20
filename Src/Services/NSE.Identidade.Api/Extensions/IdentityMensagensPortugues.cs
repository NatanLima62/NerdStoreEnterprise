using Microsoft.AspNetCore.Identity;

namespace NSE.Identidade.Api.Extensions;

public class IdentityMensagensPortugues : IdentityErrorDescriber 
{
public override IdentityError DefaultError() => new IdentityError
    {
        Code = "DefaultError",
        Description = "Ocorreu um erro desconhecido."
    };

    public override IdentityError ConcurrencyFailure() => new IdentityError
    {
        Code = "ConcurrencyFailure",
        Description = "Ocorreu falha de concorrência."
    };

    public override IdentityError PasswordMismatch() => new IdentityError
    {
        Code = "PasswordMismatch",
        Description = "Senha incorreta."
    };

    public override IdentityError InvalidToken() => new IdentityError
    {
        Code = "InvalidToken",
        Description = "Token inválido."
    };

    public override IdentityError LoginAlreadyAssociated() => new IdentityError
    {
        Code = "LoginAlreadyAssociated",
        Description = "Login já associado a outro usuário."
    };

    public override IdentityError InvalidUserName(string userName) => new IdentityError
    {
        Code = "InvalidUserName",
        Description = $"O nome do usuário '{userName}' é inválido, pode conter apenas letras ou dígitos."
    };

    public override IdentityError InvalidEmail(string email) => new IdentityError
    {
        Code = "InvalidEmail",
        Description = $"O email '{email}' é inválido."
    };
    
    public override IdentityError DuplicateUserName(string userName) => new IdentityError
    {
        Code = "DuplicateUserName",
        Description = $"O nome do usuário '{userName}' já está em uso."
    };

    public override IdentityError DuplicateEmail(string email) => new IdentityError
    {
        Code = "DuplicateEmail",
        Description = $"O email '{email}' já está em uso."
    };

    public override IdentityError InvalidRoleName(string role) => new IdentityError
    {
        Code = "InvalidRoleName",
        Description = $"O nome da função '{role}' é inválido."
    };

    public override IdentityError DuplicateRoleName(string role) => new IdentityError
    {
        Code = "DuplicateRoleName",
        Description = $"A função '{role}' já está em uso."
    };

    public override IdentityError UserAlreadyHasPassword() => new IdentityError
    {
        Code = "UserAlreadyHasPassword",
        Description = "O usuário já possui uma senha."
    };

    public override IdentityError UserLockoutNotEnabled() => new IdentityError
    {
        Code = "UserLockoutNotEnabled",
        Description = "Bloqueio de usuário não habilitado."
    };
    
    public override IdentityError UserAlreadyInRole(string role) => new IdentityError
    {
        Code = "UserAlreadyInRole",
        Description = $"O usuário já está na função '{role}'."
    };
    
    public override IdentityError UserNotInRole(string role) => new IdentityError
    {
        Code = "UserNotInRole",
        Description = $"O usuário não está na função '{role}'."
    };
    
    public override IdentityError PasswordTooShort(int length) => new IdentityError
    {
        Code = "PasswordTooShort",
        Description = $"A senha deve ter pelo menos {length} caracteres."
    };
    
    public override IdentityError PasswordRequiresNonAlphanumeric() => new IdentityError
    {
        Code = "PasswordRequiresNonAlphanumeric",
        Description = "A senha deve ter pelo menos um caractere não alfanumérico."
    };
    
    public override IdentityError PasswordRequiresDigit() => new IdentityError
    {
        Code = "PasswordRequiresDigit",
        Description = "A senha deve ter pelo menos um dígito ('0'-'9')."
    };
    
    public override IdentityError PasswordRequiresLower() => new IdentityError
    {
        Code = "PasswordRequiresLower",
        Description = "A senha deve ter pelo menos uma letra minúscula ('a'-'z')."
    };
    
    public override IdentityError PasswordRequiresUpper() => new IdentityError
    {
        Code = "PasswordRequiresUpper",
        Description = "A senha deve ter pelo menos uma letra maiúscula ('A'-'Z')."
    };
    
    public override IdentityError PasswordRequiresUniqueChars(int uniqueChars) => new IdentityError
    {
        Code = "PasswordRequiresUniqueChars",
        Description = $"A senha deve ter pelo menos {uniqueChars} caracteres únicos."
    };
}