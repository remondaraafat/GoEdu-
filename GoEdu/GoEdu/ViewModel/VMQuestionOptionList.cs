using GoEdu.Models;

namespace GoEdu.ViewModel
{
    public class VMQuestionOptionList
    {
        public int QuestionId { get; set; }
        public string Content {  get; set; }
        public string ModelAnswer { get; set; }

        /// options
        public List<Option> Options { get; set; }

    }
}
