using System;

public class CSharpExam : Exam
{
    private int examScore;

    public CSharpExam(int score)
    {
        this.ExamScore = score;
    }

    public int ExamScore
    {
        get
        {
            return this.examScore;
        }

        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException("Exam score must be between 0 and 100!");
            }

            this.examScore = value;
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.ExamScore, 0, 100, "Exam results calculated by score.");
    }
}
