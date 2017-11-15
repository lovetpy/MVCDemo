using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MVCDemo.DAL
{
    public class SqlDBContext : DbContext
    {
        /// <summary>
        /// base中指定连接字符串 gaoqihang
        /// </summary>
        public SqlDBContext() : base("SqlDBContext")
        { }
        public DbSet<SysUser> SysUsers { get; set; }
        public DbSet<SysRole> SysRoles { get; set; }
        public DbSet<SysUserRole> SysUserRoles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //指定单数形式表名
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}