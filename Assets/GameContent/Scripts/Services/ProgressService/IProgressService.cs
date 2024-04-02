public interface IProgressService //TODO: rename?
{
	void Save(string key, int value);
	int Load(string key);
}
