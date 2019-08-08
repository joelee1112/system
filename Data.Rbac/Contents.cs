using Data.Rbac.Bindings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Rbac
{
    [ModelMetadataType(typeof(ContentsMetadataType))]
    public partial class Contents : BaseEntity, IHierarchyEntity<Contents>
    {
        public Contents()
        {
            this.Children = new HashSet<Contents>();
        }

        [Key]
        [HideForEdit]
        [HideForDisplay]
        [Column("UUID")]
        public System.Guid Id { get; set; }
        public string Title { get; set; }
        public string ViewName { get; set; }
        public string Identity { get; set; }
        public string Html { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> PostTime { get; set; }
        public Nullable<System.DateTime> BeginTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public string ThumbUrl { get; set; }
        public string ImageUrl { get; set; }
        public Nullable<int> SortValue { get; set; }
        public string Url { get; set; }
        public int Sequence { get; set; }
        public Nullable<System.Guid> ParentId { get; set; }
        public Nullable<bool> IsTop { get; set; }
        public Nullable<bool> IsFooter { get; set; }
        public Nullable<bool> IsEnable { get; set; }
        public Nullable<bool> IsAgent { get; set; }
        public string FileUrl { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
        public ContentTypes? ContentType { get; set; }

        [ForeignKey("ParentId")]
        public virtual Contents Parent { get; set; }
        public virtual ICollection<Contents> Children { get; set; }

        public Contents Clone()
        {
            var item = new Contents
            {
                Id = Guid.NewGuid(),
                Title = this.Title,
                ViewName = this.ViewName,
                Identity = this.Identity,
                Html = this.Html,
                Description = this.Description,
                PostTime = this.PostTime,
                ThumbUrl = this.ThumbUrl,
                ImageUrl = this.ImageUrl,
                SortValue = this.SortValue,
                Url = this.Url,
                Sequence = this.Sequence,
                IsTop = this.IsTop,
                IsFooter = this.IsFooter,
                IsEnable = this.IsEnable,
                IsAgent = this.IsAgent,
                FileUrl = this.FileUrl,
                Text = this.Text,
                Email = this.Email,
                ContentType = this.ContentType
            };
            return item;
        }

        public string GetTitle() => Title;
        public string GetTypeName() => "content";
        public void SetTitle(string v)
        {
            Title = v;
        }
    }

    public class ContentsMetadataType
    {
        [Required]
        [Display(Name = "標題")]
        public string Title { get; set; }
        //[AllowHtml]
        [DataType("Html")]
        public string Html { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "資料發布日期")]

        public Nullable<System.DateTime> PostTime { get; set; }
        [DataType("Image")]
        [Display(Name = "照片")]
        public string ImageUrl { get; set; }
        [DataType("Image")]
        [Display(Name = "縮圖")]
        public string ThumbUrl { get; set; }
        //[DataType("File")]
        [Display(Name = "檔案")]
        public string FileUrl { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "描述")]
        public string Description { get; set; }
        [Display(Name = "連結")]
        public string Url { get; set; }
        public string Email { get; set; }
        [Display(Name = "是否顯示於上方")]
        public bool? IsTop { get; set; }
        [Display(Name = "是否顯示於下方")]
        public bool? IsFooter { get; set; }
        [Display(Name = "是否為代理")]
        public bool? IsAgent { get; set; }
        [Display(Name = "是否啟用")]
        public bool? IsEnable { get; set; }
        [Display(Name = "輪播排序")]
        public Nullable<int> SortValue { get; set; }
        [Display(Name = "節點類型")]
        public ContentTypes? ContentType { get; set; }

        //[DataType("DropDownList")]
        [Display(Name = "樣版")]
        public string ViewName { get; set; }

        [ScaffoldColumn(false)]
        public System.Guid Id { get; set; }

        [ScaffoldColumn(false)]
        public Nullable<System.DateTime> CreateTime { get; set; }
        [ScaffoldColumn(false)]
        public Nullable<System.Guid> ParentId { get; set; }
        [ScaffoldColumn(false)]
        public Nullable<int> Sequence { get; set; }
    }

}
