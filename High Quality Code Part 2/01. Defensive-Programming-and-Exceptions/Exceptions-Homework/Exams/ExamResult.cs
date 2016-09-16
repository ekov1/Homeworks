using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("Grade cannot be less than 0!");
        }

        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("Minimum grade cannot be less than 0!");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("Max grade cannot be less or equal to minimum grade!");
        }

        if (string.IsNullOrEmpty(comments))
        {
            throw new ArgumentNullException("Comments cannot be null or empty!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
