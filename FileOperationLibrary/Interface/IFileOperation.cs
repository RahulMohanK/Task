using System.Collections.Generic;
namespace FileOperationLibrary
{
    interface IFileOperation
    {
        void AddToFile<T>(T obj);
        void RetrieveAllFromFile<T>();
        void DeleteFromFile<T>(string EmpId);
        void UpdateFile<T>(string EmpId, T obj);
        void RetrieveFromFile<T>(string name);

    }
}