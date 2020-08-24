using System.Collections.Generic;
namespace FileOperationLibrary
{
    interface IFileOperation
    {
        void AddToFile<T>(T obj);
        void RetrieveAllFromFile<T>();
        void DeleteFromFile<T>(int id);
        void UpdateFile<T>(int id, T obj);
        void RetrieveFromFile<T>(string name);

    }
}