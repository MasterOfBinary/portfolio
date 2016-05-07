% Runs pagerank tests using different values for n and beta

% Numbers of websites
ns = [10 100 1000];

% Probabilities of link from website A to website B
betas = [0.1 0.3 0.5 0.7 0.9];

for i = 1:length(ns)
    for j = 1:length(betas)
        % Do 10 tests
        testPR(ns(i), betas(j), 10);
    end
end
