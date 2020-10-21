#include "ObjectList.h"
#include <fstream>
#include <string>

void ObjectList::AddObject(LevelObject newObject)
{
	_objectList.push_back(newObject);
}

void ObjectList::RemoveObject(int index)
{
	_objectList.erase(_objectList.begin() + index);
}

LevelObject ObjectList::GetObject(int index)
{
	return _objectList[index];
}

int ObjectList::GetObjectTotal()
{
	return _objectList.size();
}

void ObjectList::ClearList()
{
	_objectList.clear();
}

bool ObjectList::SaveToFile(char* str)
{
	//only write if objects in list
	if (_objectList.size() == 0){
		return false;
	}
	else {
		size_t length = strlen(str);

		std::string filename(str, length);
		std::ofstream file(filename);

		for (int i = 0; i < _objectList.size(); i++) {
			file << _objectList[i].ID << std::endl;
			file << _objectList[i].x << std::endl;
			file << _objectList[i].y << std::endl;
			file << _objectList[i].z << std::endl;
		}
		file.close();
		return true;
	}
}

bool ObjectList::LoadFromFile(char* str)
{
	size_t length = strlen(str);
	std::string filename(str, length);
	std::ifstream file(filename);

	if (!_objectList.empty()) {
		ClearList();
	}

	LevelObject newObject;
	while (file >> newObject.ID >> newObject.x >> newObject.y >> newObject.z) {
		AddObject(newObject);
	}
	file.close();
	return true;
}
