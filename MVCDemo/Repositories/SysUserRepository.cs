using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Models;
using MVCDemo.DAL;

namespace MVCDemo.Repositories
{
    /*
     * 仓储模式
     * 通过IsysUserRepository接口对象引用SysUserRepository类的实例来调用：
     * ISysUserRepository ur=new SysUserRepository();
     * var user=ur.xxx; 
    */
    /// <summary>
    /// 
    /// </summary>
    public class SysUserRepository : IsysUserRepository
    {
        protected SqlDBContext db = new SqlDBContext();
        public void Add(SysUser sysUser)
        {
            db.SysUsers.Add(sysUser);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var delSysUser = db.SysUsers.FirstOrDefault(u => u.ID == id);
            if (delSysUser != null)
            {
                db.SysUsers.Remove(delSysUser);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IQueryable<SysUser> SelectAll()
        {
            return db.SysUsers;
        }

        public SysUser SelectByName(string userName)
        {
            return db.SysUsers.FirstOrDefault(u => u.UserName == userName);
        }
    }
}