using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDE_Web_API.Models;

public class SurveyDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int SurveyId { get; set; }
    public virtual SurveyRequest SurveyRequest { get; set; }

    public int User { get; set; }
    public virtual Account UserAccount { get; set; }
}
