using fsci.client.Models;
using fsci.client.view;

namespace fsci.client.Commands;

public interface IOperateOnView
{
    void SetOutputHandler(IOutputHandler outputHandler);
}