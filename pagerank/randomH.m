function [H] = randomH(n, beta)
% Creates a random nxn hyperlink matrix given a number of websites, n, and
% a probability of website A having a link to website B, beta. If
% beta is small, H will be more sparse.

H = zeros(n, n);

for i = 1:n
    for j = 1:n
        % Can't link to self
        if j == i
            continue
        end
        
        % Random probability of having an outgoing link to another site
        link = rand();
        if link < beta
            H(i, j) = 1;
        end
    end
    
    % Normalize the row if nonzero
    if (norm(H(i, :), 1) > 0)
        H(i, :) = H(i, :) / norm(H(i, :), 1);
    end
end


