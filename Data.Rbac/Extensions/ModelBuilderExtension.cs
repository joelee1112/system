using Data.Rbac;
using System;

namespace Microsoft.EntityFrameworkCore
{
    public static class ModelBuilderExtension
    {
        public static void InitialData(this ModelBuilder builder)
        {
            builder.Entity<Users>().HasData(
                new Users { EmailConfirmed = true, Id = new Guid("7dff330c-8869-4b84-810b-606e7c1094df"), LockoutEnabled = true, UserName = "admin", NormalizedUserName = "ADMIN", Email = "admin@admin", PasswordHash = "AQAAAAEAACcQAAAAENOmhMBPlxDoF/ZywhSLYLEkyIZWSLqpn/j0AVVc1G0H+r6VuG6mvbIE8ZQc5zI5+w==", SecurityStamp = "379568e2-bf1c-476f-834c-0a54fcdeeaa3", ConcurrencyStamp = "90838d5f-e38c-4fa7-99dd-f2166b0fd53a", Name = "系統管理員" }
            );

            builder.Entity<Roles>().HasData(
              new Roles { Id = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e"), Name = "系統管理員", Description = "Administrators" }
            );

            builder.Entity<UsersRoles>().HasData(
              new UsersRoles { UserId = new Guid("7dff330c-8869-4b84-810b-606e7c1094df"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") }
            );

            builder.Entity<Menus>().HasData(
                new Menus { Id = new Guid("be2fcc62-93cb-11e8-b864-001e33280ef0"), Name = "系統管理", Sequence = 0 }
            );

            builder.Entity<Pages>().HasData(
                new Pages { Id = new Guid("0b8046e3-96c2-11e8-b864-001e33280ef0"), Name = "新增表單", ParentId = new Guid("2de69e38-96bb-11e8-b864-001e33280ef0"), Url = "/forms/create", Sequence = 0 },
                new Pages { Id = new Guid("0b805c1a-96c2-11e8-b864-001e33280ef0"), Name = "修改表單", ParentId = new Guid("2de69e38-96bb-11e8-b864-001e33280ef0"), Url = "/forms/edit/:id", Sequence = 0 },
                new Pages { Id = new Guid("2de69e00-96bb-11e8-b864-001e33280ef0"), Name = "內容管理", MenuId = new Guid("be2fcc62-93cb-11e8-b864-001e33280ef0"), Url = "/contents", Sequence = 3 },
                new Pages { Id = new Guid("2de69e38-96bb-11e8-b864-001e33280ef0"), Name = "表單管理", MenuId = new Guid("be2fcc62-93cb-11e8-b864-001e33280ef0"), Url = "/forms", Sequence = 4 },
                new Pages { Id = new Guid("363dc59f-f99d-47a0-ab15-64c7c574dac8"), Name = "新增樣版", ParentId = new Guid("ea861cdd-6977-41cb-bfc3-0a039920a945"), Url = "/layouts/create", Sequence = 0 },
                new Pages { Id = new Guid("9a9442c1-93cd-11e8-b864-001e33280ef0"), Name = "會員管理", MenuId = new Guid("be2fcc62-93cb-11e8-b864-001e33280ef0"), Url = "/users", Sequence = 0 },
                new Pages { Id = new Guid("bbd71586-952f-11e8-b864-001e33280ef0"), Name = "修改會員", ParentId = new Guid("9a9442c1-93cd-11e8-b864-001e33280ef0"), Url = "/users/edit/:id", Sequence = 0 },
                new Pages { Id = new Guid("cc42343e-93d7-11e8-b864-001e33280ef0"), Name = "新增會員", ParentId = new Guid("9a9442c1-93cd-11e8-b864-001e33280ef0"), Url = "/users/create", Sequence = 0 },
                new Pages { Id = new Guid("d4d1450e-9600-11e8-b864-001e33280ef0"), Name = "角色管理", MenuId = new Guid("be2fcc62-93cb-11e8-b864-001e33280ef0"), Url = "/roles", Sequence = 1 },
                new Pages { Id = new Guid("daa2936c-739b-4fe5-9c76-025e120a9ebc"), Name = "修改樣版", ParentId = new Guid("ea861cdd-6977-41cb-bfc3-0a039920a945"), Url = "/layouts/edit/:id", Sequence = 1 },
                new Pages { Id = new Guid("daad7a6d-9600-11e8-b864-001e33280ef0"), Name = "新增角色", ParentId = new Guid("d4d1450e-9600-11e8-b864-001e33280ef0"), Url = "/roles/create", Sequence = 0 },
                new Pages { Id = new Guid("dd9e5f7c-9600-11e8-b864-001e33280ef0"), Name = "修改角色", ParentId = new Guid("d4d1450e-9600-11e8-b864-001e33280ef0"), Url = "/roles/edit/:id", Sequence = 0 },
                new Pages { Id = new Guid("ea861cdd-6977-41cb-bfc3-0a039920a945"), Name = "樣版管理", MenuId = new Guid("be2fcc62-93cb-11e8-b864-001e33280ef0"), Url = "/layouts", Sequence = 5 },
                new Pages { Id = new Guid("f452aa01-952d-11e8-b864-001e33280ef0"), Name = "功能管理", MenuId = new Guid("be2fcc62-93cb-11e8-b864-001e33280ef0"), Url = "/functions", Sequence = 2 }
            );

            builder.Entity<Apis>().HasData(
                new Apis { Id = new Guid("08d5fce7-3c02-aa02-db5c-5b93c93fa6bf"), Name = "get", PageId = new Guid("9a9442c1-93cd-11e8-b864-001e33280ef0"), Url = "/data/users", Sequence = 3 },
                new Apis { Id = new Guid("08d5fce7-47b6-8c23-fdce-b11750c27e44"), Name = "get", PageId = new Guid("bbd71586-952f-11e8-b864-001e33280ef0"), Url = "/data/users/{id}", Sequence = 0 },
                new Apis { Id = new Guid("08d5fce7-763e-b18f-8a19-f63813836de2"), Name = "post", PageId = new Guid("cc42343e-93d7-11e8-b864-001e33280ef0"), Url = "/data/users", Sequence = 1 },
                new Apis { Id = new Guid("08d5fce7-8584-7cbf-7848-447528455b39"), Name = "put", PageId = new Guid("bbd71586-952f-11e8-b864-001e33280ef0"), Url = "/data/users/{id}", Sequence = 2 },
                new Apis { Id = new Guid("08d5fce9-282b-7d32-6075-8eb0adbfbd4a"), Name = "delete", PageId = new Guid("9a9442c1-93cd-11e8-b864-001e33280ef0"), Url = "/data/users/{id}", Sequence = 4 },
                new Apis { Id = new Guid("0d986260-92c9-41d2-b7b6-edbf714cfedb"), Name = "get", PageId = new Guid("f452aa01-952d-11e8-b864-001e33280ef0"), Url = "/data/functions", Sequence = 0 },
                new Apis { Id = new Guid("195ed512-80e3-402f-b4bb-75fe39da9523"), Name = "post", PageId = new Guid("daad7a6d-9600-11e8-b864-001e33280ef0"), Url = "/data/roles/{id}", Sequence = 0 },
                new Apis { Id = new Guid("1b494650-0dc7-4d3f-ad6e-7b68616b3afc"), Name = "get", PageId = new Guid("bbd71586-952f-11e8-b864-001e33280ef0"), Url = "/data/roles", Sequence = 1 },
                new Apis { Id = new Guid("1ca5c33d-e3e6-4158-ac93-4f9008aed18b"), Name = "put", PageId = new Guid("daa2936c-739b-4fe5-9c76-025e120a9ebc"), Url = "/data/layouts/{id}", Sequence = 1 },
                new Apis { Id = new Guid("31e1f8cf-6e87-47cd-b7c7-8c6f3759fe64"), Name = "delete", PageId = new Guid("d4d1450e-9600-11e8-b864-001e33280ef0"), Url = "/data/roles/{id}", Sequence = 0 },
                new Apis { Id = new Guid("34e7ff66-02fb-4263-81de-99717ab3039c"), Name = "get", PageId = new Guid("ea861cdd-6977-41cb-bfc3-0a039920a945"), Url = "/data/layouts", Sequence = 2 },
                new Apis { Id = new Guid("371a36aa-b3ff-46ee-95ac-83984faef3fc"), Name = "get", PageId = new Guid("cc42343e-93d7-11e8-b864-001e33280ef0"), Url = "/data/roles", Sequence = 0 },
                new Apis { Id = new Guid("6c4342a5-498e-4e8a-9f02-030bdf14d1d4"), Name = "post", PageId = new Guid("363dc59f-f99d-47a0-ab15-64c7c574dac8"), Url = "/data/layouts", Sequence = 0 },
                new Apis { Id = new Guid("732be47f-38f3-418c-b6c3-7d7f4bf78430"), Name = "get", PageId = new Guid("dd9e5f7c-9600-11e8-b864-001e33280ef0"), Url = "/data/roles/{id}", Sequence = 0 },
                new Apis { Id = new Guid("b5c73b53-a5b8-4775-899c-d4bf7e2e4cec"), Name = "get", PageId = new Guid("d4d1450e-9600-11e8-b864-001e33280ef0"), Url = "/data/roles", Sequence = 2 },
                new Apis { Id = new Guid("c064c2c6-337e-44b4-af03-b8f08f993eaf"), Name = "get", PageId = new Guid("daa2936c-739b-4fe5-9c76-025e120a9ebc"), Url = "/data/layouts/{id}", Sequence = 0 },
                new Apis { Id = new Guid("d4cb06d8-2d05-4fb6-b85d-81ec5c588082"), Name = "put", PageId = new Guid("f452aa01-952d-11e8-b864-001e33280ef0"), Url = "/data/functions/{type}/rename", Sequence = 3 },
                new Apis { Id = new Guid("e05440e1-1ac8-4802-a804-97fb0664cfb5"), Name = "delete", PageId = new Guid("ea861cdd-6977-41cb-bfc3-0a039920a945"), Url = "/data/layouts/{id}", Sequence = 3 },
                new Apis { Id = new Guid("e26da884-db42-4e13-b48a-1e703f4bbab4"), Name = "put", PageId = new Guid("dd9e5f7c-9600-11e8-b864-001e33280ef0"), Url = "/data/roles/{id}", Sequence = 1 },
                new Apis { Id = new Guid("e7b58ff0-64f4-47ad-b93c-feb17b472502"), Name = "delete", PageId = new Guid("f452aa01-952d-11e8-b864-001e33280ef0"), Url = "/data/functions/{type}", Sequence = 5 },
                new Apis { Id = new Guid("ef4daa35-8a7a-4865-96de-139d08cc60a6"), Name = "post", PageId = new Guid("f452aa01-952d-11e8-b864-001e33280ef0"), Url = "/data/functions/{type}", Sequence = 1 },
                new Apis { Id = new Guid("ef9f6272-78ea-4d49-949f-df43c6da31a2"), Name = "post", PageId = new Guid("f452aa01-952d-11e8-b864-001e33280ef0"), Url = "/data/functions/{type}/copy", Sequence = 2 },
                new Apis { Id = new Guid("f2c0bfe3-69bd-4217-8369-9f45705578d5"), Name = "put", PageId = new Guid("f452aa01-952d-11e8-b864-001e33280ef0"), Url = "/data/functions/{type}/move", Sequence = 4 }
            );

            builder.Entity<RolesMenus>().HasData(
                new RolesMenus { MenuId = new Guid("be2fcc62-93cb-11e8-b864-001e33280ef0"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") }
            );

            builder.Entity<RolesPages>().HasData(
                new RolesPages { PageId = new Guid("0b8046e3-96c2-11e8-b864-001e33280ef0"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesPages { PageId = new Guid("0b805c1a-96c2-11e8-b864-001e33280ef0"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesPages { PageId = new Guid("2de69e00-96bb-11e8-b864-001e33280ef0"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesPages { PageId = new Guid("2de69e38-96bb-11e8-b864-001e33280ef0"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesPages { PageId = new Guid("363dc59f-f99d-47a0-ab15-64c7c574dac8"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesPages { PageId = new Guid("9a9442c1-93cd-11e8-b864-001e33280ef0"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesPages { PageId = new Guid("bbd71586-952f-11e8-b864-001e33280ef0"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesPages { PageId = new Guid("cc42343e-93d7-11e8-b864-001e33280ef0"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesPages { PageId = new Guid("d4d1450e-9600-11e8-b864-001e33280ef0"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesPages { PageId = new Guid("daa2936c-739b-4fe5-9c76-025e120a9ebc"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesPages { PageId = new Guid("daad7a6d-9600-11e8-b864-001e33280ef0"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesPages { PageId = new Guid("dd9e5f7c-9600-11e8-b864-001e33280ef0"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesPages { PageId = new Guid("ea861cdd-6977-41cb-bfc3-0a039920a945"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesPages { PageId = new Guid("f452aa01-952d-11e8-b864-001e33280ef0"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") }
            );

            builder.Entity<RolesApis>().HasData(
                new RolesApis { ApiId = new Guid("08d5fce7-3c02-aa02-db5c-5b93c93fa6bf"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("08d5fce7-47b6-8c23-fdce-b11750c27e44"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("08d5fce7-763e-b18f-8a19-f63813836de2"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("08d5fce7-8584-7cbf-7848-447528455b39"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("08d5fce9-282b-7d32-6075-8eb0adbfbd4a"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("0d986260-92c9-41d2-b7b6-edbf714cfedb"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("195ed512-80e3-402f-b4bb-75fe39da9523"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("1b494650-0dc7-4d3f-ad6e-7b68616b3afc"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("1ca5c33d-e3e6-4158-ac93-4f9008aed18b"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("31e1f8cf-6e87-47cd-b7c7-8c6f3759fe64"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("34e7ff66-02fb-4263-81de-99717ab3039c"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("371a36aa-b3ff-46ee-95ac-83984faef3fc"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("6c4342a5-498e-4e8a-9f02-030bdf14d1d4"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("732be47f-38f3-418c-b6c3-7d7f4bf78430"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("b5c73b53-a5b8-4775-899c-d4bf7e2e4cec"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("c064c2c6-337e-44b4-af03-b8f08f993eaf"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("d4cb06d8-2d05-4fb6-b85d-81ec5c588082"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("e05440e1-1ac8-4802-a804-97fb0664cfb5"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("e26da884-db42-4e13-b48a-1e703f4bbab4"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("e7b58ff0-64f4-47ad-b93c-feb17b472502"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("ef4daa35-8a7a-4865-96de-139d08cc60a6"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("ef9f6272-78ea-4d49-949f-df43c6da31a2"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") },
                new RolesApis { ApiId = new Guid("f2c0bfe3-69bd-4217-8369-9f45705578d5"), RoleId = new Guid("e48ac4a9-83be-4110-828e-4352ed8bb20e") }
            );
        }
    }
}
