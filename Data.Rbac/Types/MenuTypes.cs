using System.ComponentModel.DataAnnotations;

namespace Data.Rbac
{
    public enum MenuTypes : int
    {
        /// <summary>
        /// 選單
        /// </summary>
        [Display(Name = "選單")]
        Menu = 1,
        /// <summary>
        /// 一般功能
        /// </summary>
        [Display(Name = "連結")]
        Link = 2,
        /// <summary>
        /// 按鈕
        /// </summary>
        [Display(Name = "按鈕")]
        Button = 8,
        /// <summary>
        /// 權限
        /// </summary>
        [Display(Name = "權限")]
        Permission = 9
    }
}
