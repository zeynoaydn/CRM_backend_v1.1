using Business.Abstract;
using Business.Constants;
using Core.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaim(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash,out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                User_First_Name = userForRegisterDto.User_First_Name,
                User_Last_Name = userForRegisterDto.User_Last_Name,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                //Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user,Messages.UserSuccessLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExits);
            }
            return new SuccessResult();
        }
    }
}
