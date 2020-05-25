using System.Collections.Generic;
using Neo4j.Driver;

namespace Neo4j
{
  delegate void OnCommit(/*IStatementResult*/ IResult result);

  class PendingCypher
  {
    public string Query { get; set; }
    public Dictionary<string, object> Props { get; set; }

    public OnCommit Committed { get; set; }
  }
}
