using FluentValidation;
using Bps.BpsBase.Entities.Concrete;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation
{
    public class LogsValidator : AbstractValidator<Logs>
    {
        #region ClientService

        #endregion ClientService

        public LogsValidator()
        {
            RuleFor(p => p.Detail).MaximumLength(-1);
            RuleFor(p => p.Audit).MaximumLength(50);
            RuleFor(p => p.UserKod).MaximumLength(50);
            RuleFor(p => p.ProjeKod).MaximumLength(50);
            RuleFor(p => p.KaynakKod).MaximumLength(50);
            RuleFor(p => p.IsCompare).MaximumLength(50);
            RuleFor(p => p.TEKNAD).MaximumLength(6);
            RuleFor(p => p.TableId).MaximumLength(50);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
