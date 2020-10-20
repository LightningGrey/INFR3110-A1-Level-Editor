#include "Wrapper.h"

ObjectList list;

PLUGIN_API void AddObject(LevelObject newObject)
{
	return list.AddObject(newObject);
}

PLUGIN_API void RemoveObject(int index)
{
	return list.RemoveObject(index);
}

PLUGIN_API LevelObject GetObject(int index)
{
	return list.GetObject(index);
}

PLUGIN_API int GetObjectTotal()
{
	return list.GetObjectTotal();
}

PLUGIN_API void ClearList()
{
	return list.ClearList();
}

PLUGIN_API bool SaveToFile(char* str)
{
	return list.SaveToFile(str);
}

PLUGIN_API bool LoadFromFile(char* str)
{
	return list.LoadFromFile(str);
}
