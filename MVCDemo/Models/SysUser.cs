using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    /*
    1.EF生成数据库时，ID 属性将会成为主键。（约定：EF默认会将ID或classnameID生成主键， MSDN建议保持风格的一致性, 都用ID或classnameID, 我们这里都用ID）
    2.EF 生成数据库时 , <navigation property name><primary key property name>这种形式的会成为外键. ( 约定 )例如外键 SysUserID = SysUser(navigation property)+ID(SysUser的主键)
    3.定义为virtual的几个属性是 navigation 属性(virtual非必须, 只是惯例用法, 后面文章将会讲解用virtual的好处) 

    微软官方推出的ORM框架主要有Linq to SQL和Entity Framework
    以前面的SysUser为例：
    O(Object) → 程序中的类 SysUser, 就是对象
    R (Relation) → 数据库中的表
    M(Mapping) → O和R的映射关系
    ORM对传统方式的改进：充当桥梁，实现了关系数据和对象数据的映射，通过映射自动产生SQL语句。
    */
    /// <summary>
    /// 
    /// </summary>
    public class SysUser
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<SysUserRole> SysUserRoles { get; set; }
    }
}