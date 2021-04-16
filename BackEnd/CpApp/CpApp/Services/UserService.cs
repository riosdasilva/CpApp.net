using CpApp.Data.DTO;
using CpApp.Interfaces;
using CpApp.Models;
using CpApp.Repositories;
using CpApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CpApp.Services
{
    public class UserService : IUserService
    {
        private IGenericRepository<User> _clientRepository;

        public UserService(IGenericRepository<User> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<User> AddAsync(User client)
        {
            return await _clientRepository.AddAsync(client);
        }
        public async Task<User> UpdateAsync(User client, int id)
        {
            IEnumerable<User> Users = _clientRepository.GetAll();
            User clientO = Users.FirstOrDefault(i => i.Id == id);
            clientO.Name      = client.Name;
            clientO.Username  = client.Username;
            clientO.Nationaly = client.Nationaly;
            clientO.Email     = client.Email;
            clientO.Birthday  = client.Birthday;
            clientO.Password  = client.Password;
            return await _clientRepository.UpdateAsync(clientO);
        }
        public void Delete(int id)
        {
           User client = FindById(id);
           _clientRepository.Delete(client);
        }

        public IQueryable<User> GetAllClient()
        {
            return _clientRepository.GetAll();
        }

        public User FindById(int id)
        {
           IEnumerable<User> Users =_clientRepository.GetAll();
           User client = Users.FirstOrDefault(i => i.Id == id);
           
           return client;
        }

        public User ValidateCredentials(UserDTO user)
        {
            IQueryable<User> users = GetAllClient();
            User client = users.FirstOrDefault(u => (u.Username == user.UserName) && u.Password == user.Password);
            return client;
        }

        public string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        public User RefreshUserInfo(User user)
        {
            User u = FindById(user.Id);
            if (u != null)
            {
                try
                {
                    _clientRepository.UpdateAsync(u);

                }
                catch(Exception)
                {
                    throw;
                }
                
            }

            return u;
           
        }

        public User ValidateCredentials(string username)
        {
            IQueryable < User > users = GetAllClient();
            return users.SingleOrDefault(u => (u.Username == username));
        }
    }
}
