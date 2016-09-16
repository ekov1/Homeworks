using System;

public class SimpleMathExam : Exam
{
    private int solvedProblems;

    public SimpleMathExam(int solvedProblems)
    {
        this.ProblemsSolved = solvedProblems;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.solvedProblems;
        }

        private set
        {
            var isSolvedProblemsNumberValid = value >= 0 && value <= 2;

            if (!isSolvedProblemsNumberValid)
            {
                throw new ArgumentOutOfRangeException("Solved problems must be between 0 and 2 inclusive!");
            }

            this.solvedProblems = value;
        }
    }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else if (this.ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Average result: nothing done.");
        }
        else
        {
            throw new IndexOutOfRangeException("Invalid solved problems number!");
        }
    }
}
