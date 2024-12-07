using fsci.client.Models;

namespace fsci.client.Commands;

public interface IOperateOnFileSystem
{
    void SetFileSystemHandler(IFileSystemHandler fileSystemHandler);
}