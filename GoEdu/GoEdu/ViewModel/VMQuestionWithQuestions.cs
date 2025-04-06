namespace GoEdu.ViewModel
{
    using System.ComponentModel.DataAnnotations;

    public class VMQuestionWithQuestions
    {
        [Display(Name = "محتوى السؤال")]
        [Required(ErrorMessage = "محتوى السؤال مطلوب")]
        [StringLength(500, ErrorMessage = "يجب ألا يزيد محتوى السؤال عن 500 حرف")]
        public string? Content { get; set; }

        [Display(Name = "الإجابة النموذجية")]
        [Required(ErrorMessage = "يجب اختيار الإجابة النموذجية")]
        public string? ModelAnswer { get; set; }

        [Display(Name = "معرّف المحاضرة")]
        [Required(ErrorMessage = "معرّف المحاضرة مطلوب")]
        [Range(1, int.MaxValue, ErrorMessage = "رقم المحاضرة غير صالح")]
        public int LectureId { get; set; }

        [Display(Name = "الخيار الأول")]
        [Required(ErrorMessage = "الخيار الأول مطلوب")]
        [StringLength(200, ErrorMessage = "يجب ألا يزيد الخيار الأول عن 200 حرف")]
        public string? Option1 { get; set; }

        [Display(Name = "الخيار الثاني")]
        [Required(ErrorMessage = "الخيار الثاني مطلوب")]
        [StringLength(200, ErrorMessage = "يجب ألا يزيد الخيار الثاني عن 200 حرف")]
        public string? Option2 { get; set; }

        [Display(Name = "الخيار الثالث")]
        [Required(ErrorMessage = "الخيار الثالث مطلوب")]
        [StringLength(200, ErrorMessage = "يجب ألا يزيد الخيار الثالث عن 200 حرف")]
        public string? Option3 { get; set; }

        [Display(Name = "الخيار الرابع")]
        [Required(ErrorMessage = "الخيار الرابع مطلوب")]
        [StringLength(200, ErrorMessage = "يجب ألا يزيد الخيار الرابع عن 200 حرف")]
        public string? Option4 { get; set; }

        [Display(Name = "قائمة الأسئلة")]
        [Required(ErrorMessage = "يجب إدخال قائمة الأسئلة")]
        [MinLength(1, ErrorMessage = "يجب إدخال سؤال واحد على الأقل")]
        public List<VMQuestionOptionList>? Questions { get; set; }
    }

}
