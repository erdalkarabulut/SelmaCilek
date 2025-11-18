using FluentValidation;
using Bps.BpsBase.Entities.Concrete.IK;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.IK
{
    public class IkpersValidator : AbstractValidator<IKPERS>
    {
        #region ClientService

        #endregion ClientService

        public IkpersValidator()
        {
            RuleFor(p => p.SICILN).Length(1,50).NotNull();
            RuleFor(p => p.GNNAME).Length(1,50).NotNull();
            RuleFor(p => p.GNSNAM).Length(1,50).NotNull();
            RuleFor(p => p.DEPAKD).Length(1,20).NotNull();
            RuleFor(p => p.POZSKD).Length(1,20).NotNull();
            RuleFor(p => p.LOKAKD).Length(1,20).NotNull();
            RuleFor(p => p.ISYKOD).MaximumLength(20);
            RuleFor(p => p.GNMAIL).MaximumLength(100);
            RuleFor(p => p.ISGRTR).NotNull();
            RuleFor(p => p.CNEDKD).MaximumLength(20);
            RuleFor(p => p.CLDRKD).Length(1,20).NotNull();
            RuleFor(p => p.MSRFKD).MaximumLength(20);
            RuleFor(p => p.DOGYER).MaximumLength(50);
            RuleFor(p => p.UYRKKD).MaximumLength(20);
            RuleFor(p => p.CINSKD).Length(1,20).NotNull();
            RuleFor(p => p.MHALKD).MaximumLength(20);
            RuleFor(p => p.EVTELF).MaximumLength(15);
            RuleFor(p => p.CEPTEL).MaximumLength(15);
            RuleFor(p => p.ADRESS).MaximumLength(500);
            RuleFor(p => p.MAHAKD).MaximumLength(20);
            RuleFor(p => p.ILCEKD).MaximumLength(20);
            RuleFor(p => p.SEHRKD).MaximumLength(20);
            RuleFor(p => p.ULKEKD).MaximumLength(20);
            RuleFor(p => p.ACLTEL).MaximumLength(15);
            RuleFor(p => p.ACLCEP).MaximumLength(15);
            RuleFor(p => p.ACLKIS).MaximumLength(100);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
