using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCDemo.DAL
{
    /// <summary>
    /// 第一次运行程序时新建数据库，插入测试数据； model改变（和database不一致）时删除重建数据库，插入测试数据
    /// 目前在开发阶段，不用管数据丢失的问题，直接drop and re-create比较方便。等系列文章结束后会讲解生产环境中如何不丢失数据修改schema
    /// </summary>
    public class SqlDBInitializer : DropCreateDatabaseIfModelChanges<SqlDBContext>
    {
        protected override void Seed(SqlDBContext context)
        {
            var sysUsers = new List<SysUser>
            {
                new SysUser { UserName="Tom",Email="Tom@sohu.com",Password="1" },
                new SysUser { UserName="Jerry",Email="Jerry@sohu.com",Password="2" }
            };
            sysUsers.ForEach(s => context.SysUsers.Add(s));
            context.SaveChanges();

            var sysRoles = new List<SysRole>
            {
                new SysRole { RoleName="Administrator",RoleDesc="Administrators have full auth" },
                new SysRole { RoleName="General Users",RoleDesc="General Users"}
            };
            sysRoles.ForEach(s => context.SysRoles.Add(s));
            context.SaveChanges();
            //不一定要在每个entity组后面都调用SaveChanges方法，可以在所有组结束后调用一次也可以。这样做是因为如果写入数据库代码出错，比较容易定位代码的错误位置

            var sysUserRoles = new List<SysUserRole>
            {
                new SysUserRole { SysUserID=1,SysRoleID=1 },
                new SysUserRole { SysUserID=1,SysRoleID=2 },
                new SysUserRole { SysUserID=2,SysRoleID=2 }
            };
            sysUserRoles.ForEach(s => context.SysUserRoles.Add(s));
            context.SaveChanges();
        }
    }
}