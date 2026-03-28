namespace App.Domain.Exceptions
{
	public class DepartmentNotFoundException : Exception
	{
		public DepartmentNotFoundException(int departmentId)
			: base($"Department with id {departmentId} not found")
		{
		}
	}
}