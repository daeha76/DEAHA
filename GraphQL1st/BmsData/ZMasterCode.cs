using System.ComponentModel.DataAnnotations.Schema;

namespace DAEHA.GraphQL1st.BmsData;

[Table("ZMasterCode")]
public class ZMasterCode
{
	[Key]
	public string MCode { get; set; }
	public string PMCode { get; set; }
	public string Category { get; set; }
	public string ItemName { get; set; }
	public string Conditions { get; set; }
	public int SortNum { get; set; }
	public string Description { get; set; }
	public bool IsRemove { get; set; }
}
