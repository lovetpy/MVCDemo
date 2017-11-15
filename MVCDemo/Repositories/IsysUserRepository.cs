using MVCDemo.Models;
using System.Linq;

namespace MVCDemo.Repositories
{
    public interface IsysUserRepository
    {
        //查询所有用户
        IQueryable<SysUser> SelectAll();

        //通过用户名查询用户
        SysUser SelectByName(string userName);

        //添加用户
        void Add(SysUser sysUser);

        //删除用户
        bool Delete(int id);
    }
}
