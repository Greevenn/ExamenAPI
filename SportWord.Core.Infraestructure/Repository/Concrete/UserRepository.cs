using System;
using System.Collections.Generic;
using System.Text;
using SportWord.Core.Infraestructure.Repository.Abstract;
using SportWord.Core.Domain.Models;
using SportWord.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace SportWord.Core.Infraestructure.Repository.Concrete
{
    public class UserRepository : IBaseRepository<User, Guid>
    {
        private DB db; //Constructor
        public UserRepository(DB db)
        {
            this.db = db;
        }

        public User Create(User user)
        {
            user.usuario_id = Guid.NewGuid();
            //Define nuevo identificador unico
            db.Users.Add(user);
            return user;
        }

        public void Delete(Guid entityId)
        {
            var selectedUser = db.Users
                .Where(u => u.usuario_id == entityId).FirstOrDefault();
            //seleccionara el usuario a traves del Id
            if (selectedUser != null)
                //verifica si el usario existe
                db.Users.Remove(selectedUser);
        }

        public List<User> GetAll() //Metodo de obtener todo
        {
            return db.Users.ToList();
        }

        public User GetById(Guid entityId) //metodo de obtener por ID
        {
            var selectedUser = db.Users
                 .Where(u => u.usuario_id == entityId).FirstOrDefault();
            return selectedUser;
        }

        public void saveAllChanges()
        {
            db.SaveChanges(); //salvar todo
        }

        public User Update(User user) //actualizar
        {
            var selectedUser = db.Users
                .Where(u => u.usuario_id == user.usuario_id)
                .FirstOrDefault();
            //seleccione usaruio por el Id desde la base de datos
            if(selectedUser != null)
            {
                //verifica el usuario si existe
                selectedUser.usuario_name = user.usuario_name;
                selectedUser.email = user.email;
                selectedUser.contraseña = user.contraseña;
                selectedUser.tipo = user.tipo;

                //Modifica los datos del usario con los valores del parametro

                db.Entry(selectedUser).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                //Enmarcar el estado del usaruio como modificado.
            }
            return selectedUser;
        }
    }
}
