namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data.Models;

    class EvaluationScoreSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.EvaluationScores.Any())
            {
                return;
            }

            var evaluationScores = new List<EvaluationScore>
            {
                new EvaluationScore
                {
    Description = "Poor Performance was consistently below expectations, and/or reasonable progress toward critical goals was not made. Significant improvement is needed in one or more important areas.",
    Rate = "Poor"
                },

                new EvaluationScore
                {
    Description = " Unsatisfactory Performance failed to meet expectations, and/or one or more of the most critical goals were not met.",
    Rate = "Unsatisfactory"
                },

                new EvaluationScore
                {
    Description = " Satisfactory Performance met expectations in terms of quality of work, efficiency and timeliness. The most critical annual goals were met. ",
    Rate = "Satisfactory"
                },

                new EvaluationScore
                {
    Description = " Very Satisfactory Performance exceeded expectation. All goals, objectives, and targets were achieved above the established standards.",
    Rate = "Very_Satisfactory"
                },

                new EvaluationScore
                {
    Description = " Outstanding Performance represents an extraordinary level of achievement and commitment in terms of quality and time , technical skills and knowledge, ingenuity, creativity and initiative. Employees at this performance level should have demonstrated exceptional job mastery in all major areas of responsibility. Employee achievement and contributions to the organization are of marked excellence.",
    Rate = "Outstanding"
                }
            };

            await dbContext.EvaluationScores.AddRangeAsync(evaluationScores);
            await dbContext.SaveChangesAsync();
        }
    }
}
