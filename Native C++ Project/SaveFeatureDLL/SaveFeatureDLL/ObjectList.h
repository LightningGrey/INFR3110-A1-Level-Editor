#pragma once

#include "PluginSettings.h"
#include "LevelObject.h"
#include <vector>

class PLUGIN_API ObjectList
{
public:
	void AddObject(LevelObject newObject);
	void RemoveObject(int index);
	LevelObject GetObject(int index);
	int GetObjectTotal();
	void ClearList();
	
	bool SaveToFile(char* string);
	bool LoadFromFile(char* string);
private:
	std::vector<LevelObject> _objectList;
};

