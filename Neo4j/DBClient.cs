using System;
using System.Collections.Generic;
using Neo4j.Model;
namespace Neo4j
{
    public interface DBClient
    {
    void Dispose();
    PendingNode Push(Node node, Dictionary<string, object> variables);
    void Relate(PendingNode fromNodeId, PendingNode toNodeId, string relType, Dictionary<string, object> variables);
    //void Relate(Node fromNode, Node toNode, string relType, Dictionary<string, object> variables);

    void Commit();

  }
}
