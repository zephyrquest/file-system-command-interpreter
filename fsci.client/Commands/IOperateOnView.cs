using fsci.client.Models;

namespace fsci.client.Commands;

public interface IOperateOnView
{
    void SetOutputHandler(IOutputHandler outputHandler);
}