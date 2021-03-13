namespace com.CompanyR.FrameworkR.ProgressSystem
{
	public interface IUIElement<T> where T : AbstractXPComponent
	{
		public void InitElement(T element);

		public void UpdateElement();
	}
}
