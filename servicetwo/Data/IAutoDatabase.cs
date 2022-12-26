namespace servicetwo.Data {
	public interface IAutoDatabase {
		
		public IEnumerable<Owner> ListOwners();
		public Owner FindOwner(string id);




	}
}
