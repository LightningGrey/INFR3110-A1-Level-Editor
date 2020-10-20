#pragma once

#include "ObjectList.h"

#ifdef __cplusplus
extern "C"
{
#endif

	//functions here
	PLUGIN_API void AddObject(LevelObject newObject);

	PLUGIN_API void RemoveObject(int index);

	PLUGIN_API LevelObject GetObject(int index);

	PLUGIN_API int GetObjectTotal();

	PLUGIN_API void ClearList();

	PLUGIN_API bool SaveToFile(char* str);

	PLUGIN_API bool LoadFromFile(char* str);

#ifdef __cplusplus
}
#endif