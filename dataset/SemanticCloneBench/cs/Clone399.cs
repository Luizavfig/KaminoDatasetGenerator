/*
* Semantic clone benchmark
*  Source code are extracted from Stack Overflow
*  Stack overflow Question #:17143253
*  Stack Overflow answer #:17143571
*  And Stack Overflow answer#:17143713
*/
public PayoutResult Payout (string userName, PayoutModel model) {
    var user = this.userRepository.GetAll ().SingleOrDefault (u = > u.Username == userName);
    if (user == null) {
        return PayoutResult.UserNotFound;
    }
    bool hasWithdrawn = user.Withdraw (model);
    if (hasWithdrawn && this.userRepository.SaveUser (user)) {
        model.Balance = user.Balance;
        model.Amount = 0;
        return PayoutResult.Success;
    } else if (hasWithdrawn) {
        return PayoutResult.DBError;
    }
    return PayoutResult.FundsUnavailable;
}

[HttpPost] public ActionResult Payout (PayoutViewModel model) {
    if (ModelState.IsValid) {
        var account = accountRepository.FindAccountFor (User.Identity.Name);
        if (account.CanWithdrawMoney (model.WithdrawAmount)) {
            account.MakeWithdrawal (model.WithdrawAmount);
            ViewBag.Message = "Successfully withdrew " + model.WithdrawAmount;
            model.Balance = account.Balance;
            model.WithdrawAmount = 0;
            return View (model);
        }
        ViewBag.Message = "Not enough funds on your account";
        return View (model);
    } else {
        return View (model);
    }
}

