namespace Problems {
  interface IProblem {
    int ProblemNumber { get; }
    long Result { get; set; }
    long GetResult();
    void ComputeResult();
  }
}