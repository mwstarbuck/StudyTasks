using StudyTasks.Models;
using System.Collections.Generic;

namespace StudyTasks.DAL
{
    public interface IProvideStudyTasks
    {
        void InsertVocabulary(List<Vocabulary> words);
        List<string> GetVocabulary();
    }
}